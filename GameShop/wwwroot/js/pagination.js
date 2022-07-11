function sendNewPage(number) {
    let form = $('#pagination_form');
    const input = document.createElement("input");
    input.type = "hidden";
    input.style.display = "none";
    input.name = "currentPage";
    input.value = number;
    form.append(input);
    form.submit();
}