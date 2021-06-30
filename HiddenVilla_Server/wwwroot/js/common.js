window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, 'Operation Successful');
    } else if (type === "error") {
        toastr.error(message, 'Operation Failed');
    }
}