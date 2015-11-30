$(".date-control").datepicker({
    format: "dd.mm.yyyy",
    language: "ru"
});

$(document).ready(function () {
    Globalize.culture("ru");
});

$.validator.methods.number = function (value, element) {
    return this.optional(element) || !isNaN(Globalize.parseFloat(value));
}

$.validator.methods.date = function (value, element) {
    return this.optional(element) || Globalize.parseDate(value);
}

