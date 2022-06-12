function sendNewPage(number) {
    let form = $('#pagination_form');
    const input = document.createElement("input");
    input.type = "number";
    input.name = "currentPage";
    input.value = number;
    form.append(input);
    form.submit();
}