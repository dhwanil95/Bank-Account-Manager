document.addEventListener("DOMContentLoaded", function () {
    const withdrawBtn = document.getElementById("withdrawBtn");
    const form = document.getElementById("transactionForm");

    withdrawBtn.addEventListener("click", function () {
        form.action = "/Account/Withdraw";
        form.submit();
    });
});
