$(document).ready(function () {
    var vm = {
        customerId: '',
        movieIds: []
    };

    //customer typeahead
    var customers = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/customers?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#customer').typeahead(
        {
            minLength: 3,
            highlight: true
        },
        {
            name: 'customers',
            display: 'name',
            source: customers
        })
        .on("typeahead:select", function (e, customer) {
            vm.customerId = customer.id;
        });

    //movie typeahead
    var movies = new Bloodhound({
        datumTokenizer: Bloodhound.tokenizers.obj.whitespace('name'),
        queryTokenizer: Bloodhound.tokenizers.whitespace,
        remote: {
            url: '/api/movies?query=%QUERY',
            wildcard: '%QUERY'
        }
    });

    $('#movie').typeahead(
        {
            minLength: 2,
            highlight: true
        },
        {
            name: 'movies',
            display: 'name',
            source: movies
        })
        .on("typeahead:select", function (e, movie) {
            $("#movies").append(`<li class='list-group-item'>${movie.name}</li>`);

            $("#movie").typeahead("val", "");

            vm.movieIds.push(movie.id);
            //console.log(vm);
        });

    //validating the form.

    //custom validator for customer.
    $.validator.addMethod("validCustomer", function () {
        return vm.customerId && vm.customerId !== 0;
    }, "Please select a valid customer");

    //custom validator for movie.
    $.validator.addMethod("atLeastOneMovie", function () {
        return vm.movieIds.length > 0;
    }, "Please select atleast one movie.");

    var validator = $("#newRental").validate({
        submitHandler: function () {
            $.ajax({
                url: "/api/NewRentals",
                method: "post",
                data: vm
            }).done(function () {
                toastr.success("Rentals added successfully.");
                $("#customer").typeahead("val", "");
                $("#movie").typeahead("val", "");
                $("#movies").empty();
                vm = { customerId: '', movieIds: [] };
                validator.resetForm();

            }).fail(function () {
                toastr.fail("Something expected happen");
            });
            return false;
        }
    });
});