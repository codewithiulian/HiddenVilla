window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, 'Operation Successful');
    } else if (type === "error") {
        toastr.error(message, 'Operation Failed');
    }
}

window.ShowPopup = (type, message) => {
    if (type === "success") {
        Swal.fire({
            title: 'Success!',
            text: message,
            icon: 'success',
            confirmButtonText: 'Ok'
        })
    } else if (type === "error") {
        Swal.fire({
            title: 'Error!',
            text: message,
            icon: 'error',
            confirmButtonText: 'Ok'
        })
    }
}