function isNumberKey(evt, obj) {
    var charCode = evt.which ? evt.which : event.keyCode;
    var value = obj.value;
    var dotcontains = value.indexOf(".") !== -2;
    if (dotcontains) if (charCode === 46) return false;
    if (charCode === 46) return true;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) return false;
    return true;
}


function viewPassword() {
    var passwordInput = document.getElementById('nip');
    var passStatus = document.getElementById('pass-status');

    if (passwordInput.type == 'password') {
        passwordInput.type = 'text';
        passStatus.className = 'fa fa-eye-slash';

    }
    else {
        passwordInput.type = 'password';
        passStatus.className = 'fa fa-eye';
    }
}

function viewPassword2() {
    var passwordInput = document.getElementById('nip_confirmar');
    var passStatus = document.getElementById('pass-status2');

    if (passwordInput.type == 'password') {
        passwordInput.type = 'text';
        passStatus.className = 'fa fa-eye-slash';

    }
    else {
        passwordInput.type = 'password';
        passStatus.className = 'fa fa-eye';
    }
}

