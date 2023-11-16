document.addEventListener('DOMContentLoaded', function () {
    document.getElementById('addContact').addEventListener('click', function (event) {
        event.preventDefault();
        createContact();
    });
    document.getElementById('updateContact').addEventListener('click', function (event) {
        event.preventDefault();
        updateContact();
    });
    document.getElementById('deleteContact').addEventListener('click', function (event) {
        event.preventDefault();
        deleteContact();
        event.stopPropagation();
    });
});

function createContact() {
    let isValid = validate();
 
    if (isValid) {
        const form = document.getElementById('creatingForm');
        const contactId = document.getElementById('contactId');
        let formData = new FormData(form);
        formData.delete(contactId);

        fetch('/Contact/AddContact', {
            method: 'POST',
            body: formData,

        })
            .then(response => {
                if (response.ok) {
                    location.reload();
                }
            });
    }
}

function updateContact() {
    let isValid = validate();

    if (isValid) {
        const form = document.getElementById('creatingForm');
        let formData = new FormData(form);

        fetch('/Contact/UpdateContact', {
            method: 'PUT',
            body: formData
        })
            .then(response => {
                if (response.ok) {
                    location.reload();
                }
            });
    }
}

function deleteContact() {
    const id = document.getElementById('contactId').value;
    fetch(`/Contact/DeleteContact/${id}`, {
        method: 'DELETE'
    })
        .then(response => {
            if (response.ok) {
                location.reload();
            }
        });
}

function validate() {
    let isValid = true;

    const nameInput = document.getElementById("Name");
    const nameError = document.getElementById("nameError");
    isValid = nameValidation(nameInput, nameError) && isValid; 

    const mobilePhoneInput = document.getElementById("MobilePhone");
    const mobilePhoneError = document.getElementById("MobilePhoneError");
    isValid = mobilePhoneValidation(mobilePhoneInput, mobilePhoneError) && isValid;

    const jobTitleInput = document.getElementById("JobTitle");
    const jobTitleError = document.getElementById("JobTitleError");
    isValid = jobTitleValidation(jobTitleInput, jobTitleError) && isValid;

    const birthDateInput = document.getElementById("BirthDate");
    const birthDateError = document.getElementById("BirthDateError");
    isValid = birthDateValidation(birthDateInput, birthDateError) && isValid;

    return isValid;
}

function nameValidation(inputElement, errorElement) {
    errorElement.innerHTML = "";
    const inputValue = inputElement.value;

    if (inputValue.length < 3) {
        errorElement.innerHTML = "Имя не может содержать меньшь 3 букв"
        return false;
    }

    if (inputValue.length > 20) {
        errorElement.innerHTML = 'Имя не может содержать больше 20 букв'
        return false;
    }

    return true;
}

function jobTitleValidation(inputElement, errorElement) {
    errorElement.innerHTML = '';
    const inputValue = inputElement.value;

    if (inputValue.length < 3) {
        errorElement.innerHTML = "Название должности не может содержать меньшь 3 букв"
        return false;
    }

    if (inputValue.length > 20) {
        errorElement.innerHTML = "Название должности не может содержать больше 30 букв"
        return false;
    }

    return true;
}

function mobilePhoneValidation(inputElement, errorElement) {
    errorElement.innerHTML = "";
    const inputValue = inputElement.value;
    var phonePattern = /^\+?\d{1,4}[-.\s]?\(?\d{1,}\)?[-.\s]?\d{1,}[-.\s]?\d{1,}$/;

    if (!phonePattern.test(inputValue)) {
        errorElement.innerHTML = "Введите корректный номер телефона."
        return false;
    }

    return true;
}

function birthDateValidation(inputElement, errorElement) {
    errorElement.innerHTML = "";
    let dateString = inputElement.value;

    if (dateString == '') {
        errorElement.innerHTML = 'Заполните поле.'
        return false;
    }

    let date = parseDateString(dateString);
    let currentDate = new Date();
    
    if (date > currentDate) {
        errorElement.innerHTML = 'Эта дата еще не наступила.'
        return false;
    }
    return true;
}

function parseDateString(dateString) {
    var parts = dateString.split('-');

    var day = parseInt(parts[2], 10);
    var month = parseInt(parts[1], 10) - 1;
    var year = parseInt(parts[0], 10);

    var date = new Date(year, month, day);

    return date;
}