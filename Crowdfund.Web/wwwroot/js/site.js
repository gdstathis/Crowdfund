// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//VALIDATION GIA TO EMAIL TOU BACKER
function validateEmail(email) {

    if (!email || email.trim().length === 0) {
        return false;
    }

    if (!email.includes('@')) {
        return false;
    }

    if (!email.includes('.')) {
        return false;
    }

    return true;
}

let $emailBacker = $('.js-email');
$emailBacker.on('input', (evt) => {
    let $email = $(evt.currentTarget).val();
    let result = validateEmail($email);
    let $validationMessage = $('.js-validation-email');

    if (!result) {
        $validationMessage.show();
    } else {
        $validationMessage.hide();
        emailOk = true;
    }
    buttonBacker();
});
function buttonBacker() {
    if (vatOk && emailOk) {
        let $button = $('.js-submit');
        $button.attr('disabled', false);
    }
}
$('.js-submit-backer').on('click', () => {
    $('.js-submit-backer').attr('disabled', true);
    
    let email = $('.js-email').val();

    let data = JSON.stringify({
       
        email: email
    });
    $.ajax({
        url: '/backer/Create',
        type: 'POST',
        contentType: 'application/json',
        data: data
    }).done((backer) => {
        $('.alert').hide();
        let $alertArea = $('.js-create-backer-alert');
        $alertArea.attr("class", "alert alert-success");
        $alertArea.html(`Successfully added Backer Account  ${backer.name}`);
        $alertArea.show();
        $('form.js-create-backer').hide();
    }).fail((xhr) => {
        $('.alert').hide();
        let $alertArea = $('.js-create-backer-alert');
        $alertArea.attr("class", "alert alert-danger");
        $alertArea.html(xhr.responseText);
        $alertArea.fadeIn();

        setTimeout(function () {
            $('.js-submit-backer').attr('disabled', false);
        }, 300);
    });
});



//VALIDATION GIA TO email tou projectcretor
$('.js-submit-projectcreator').on('click', () => {

    $('.js-submit-projectcreator').attr('disabled', true);

    let email = $('.js-email').val();
    

    let data = JSON.stringify({

        email: email,
        
    });

    $.ajax({
        url: '/ProjectCreator/CreateProjectCreator',
        type: 'POST',
        contentType: 'application/json',
        data: data
    }).done((owner) => {
        $('.alert').hide();

        let $alertArea = $('.js-create-projectcreator-success');
        $alertArea.html(`Successfully added owner with name ${owner.firstname}`);
        $alertArea.show();


        $('form.js-create-owner').hide();
    }).fail((xhr) => {
        $('.alert').hide();

        let $alertArea = $('.js-create-projectcreator-alert');
        $alertArea.html(xhr.responseText);
        $alertArea.fadeIn();

        setTimeout(function () {
            $('.js-submit-owner').attr('disabled', false);
        }, 300);
    });
}); 




