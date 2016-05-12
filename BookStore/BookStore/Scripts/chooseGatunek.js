$(function () {
    $('#gatunekDialog').dialog({
        autoOpen: false,
        width: 400,
        height: 300,
        modal: true,
        title: 'Dodaj gatunek',
        buttons: {
            'Save': function () {
                var createGenreForm = $('#createGenreForm');
                if (createGenreForm.valid()) {
                    $.post(createGenreForm.attr('action'), createGenreForm.serialize(), function (data) {
                        if (data.Error != '') {
                            alert(data.Error);
                        }
                        else {
                            // Add the new genre to the dropdown list and select it
                            $('#GatunekId').append(
                                    $('<option></option>')
                                        .val(data.Gatunek.GatunekId)
                                        .html(data.Gatunek.Nazwa)
                                        .prop('selected', true)  // Selects the new Genre in the DropDown LB
                                );
                            $('#gatunekDialog').dialog('close');
                        }
                    });
                }
            },
            'Cancel': function () {
                $(this).dialog('close');
            }
        }
    });

    $('#gatunekAddLink').click(function () {
        var createFormUrl = $(this).attr('href');  
        $('#gatunekDialog').html('')
        .load(createFormUrl, function () {  
            // The createGenreForm is loaded on the fly using jQuery load. 
            // In order to have client validation working it is necessary to tell the 
            // jQuery.validator to parse the newly added content
            jQuery.validator.unobtrusive.parse('#createGenreForm');
            $('#gatunekDialog').dialog('open');
        });

        return false;
    });
});	