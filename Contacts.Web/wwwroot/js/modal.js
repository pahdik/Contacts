document.addEventListener('DOMContentLoaded', function () {
    let tableRows = document.getElementsByClassName('table-row');

    Array.from(tableRows).forEach(function (row) {
        row.addEventListener('click', function () {
            resertErrors();

            document.getElementById('addContact').classList.add('d-none');
            document.getElementById('updateContact').classList.remove('d-none');
            document.getElementById('deleteContact').classList.remove('d-none');

            let contactId = row.getAttribute('data-id');
            let name = row.getAttribute('data-name');
            let jobTitle = row.getAttribute('data-jobTitle');
            let mobilePhone = row.getAttribute('data-mobilePhone');
            let birthDate = row.getAttribute('data-birthDate').split(' ')[0];
            let dateArray = birthDate.split(".")

            document.getElementById('Name').value = name;
            document.getElementById('contactId').value = contactId;
            document.getElementById('Name').value = name;
            document.getElementById('JobTitle').value = jobTitle;
            document.getElementById('MobilePhone').value = mobilePhone;
            document.getElementById('BirthDate').value = new Date(dateArray[2], parseInt(dateArray[1]) -1, parseInt(dateArray[0])+1).toISOString().slice(0, 10);
        });
    });

    document.getElementById('openModal').addEventListener('click', function (event) {
        document.getElementById('creatingForm').reset();
        resertErrors();
        document.getElementById('addContact').classList.remove('d-none');
        document.getElementById('updateContact').classList.add('d-none');
        document.getElementById('deleteContact').classList.add('d-none');
    });
});

function resertErrors() {
    document.getElementById('nameError').innerHTML = "";
    document.getElementById('MobilePhoneError').innerHTML = '';
    document.getElementById('JobTitleError').innerHTML = '';
    document.getElementById('BirthDateError').innerHTML = '';
}