// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// Tooltips Initialization
$(function () {
    $('[data-toggle="tooltip"]').tooltip()
})


let rewards = [];

$('.js-add-reward').on('click', function () {
    let $description = $('.js-reward-description');
    let $amount = $('.js-reward-amount');

    let description = $description.val();
    let amount = parseFloat($amount.val());

    if (amount.length === 0 || description.length === 0) {
        return;
    }
    debugger;
    rewards.push({
        description: description,
        amount:amount
    });

    $description.val('');
    $amount.val('');
});


$('.js-btn-create-project').on('click', () => {
    let title = $('.js-title').val();
    let description = $('.js-description').val();
    let budget = $('.js-budget').val();
    let photo = $('.js-photo').val();

    let data = JSON.stringify({
        CreateProjectOptions: {
            title: title,
            description: description,
            budget: parseFloat(budget),
            photo: photo
        },
        rewards: rewards
    });

    if (rewards.length === 0) {
        return;
    }

    $('.js-btn-create-project').attr('disabled', true);

    $.ajax({
        url: '/project/Create',
        type: 'POST',
        contentType: 'application/json',
        data: data
    }).done((project) => {
        debugger;
        window.location.href = `/project/${project.id}`;
    }).fail((xhr) => {
        $('.alert').hide();
        let $alertArea = $('.js-create-project-alert');
        $alertArea.attr("class", "alert alert-danger");
        $alertArea.html(xhr.responseText);
        $alertArea.fadeIn();

        setTimeout(function () {
            $('.js-btn-create-project').attr('disabled', false);
        }, 300);
    });
});

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
    vatOk = true
    emailOk=true
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



//Project creator registration 
$('.js-submit-projectcreator').on('click', () => {

    $('.js-submit-projectcreator').attr('disabled', true);

    let email = $('.js-email').val();
    let firstname = $('.js-projectCreatorFirstname').val();
    let lastname = $('.js-projectCreatorLastname').val();
    let phone = $('.js-projectCreatorPhone').val();
    let data = JSON.stringify({
        AddProjectCreatorOptions: {
            Firstname: firstname,
            Lastname: lastname,
            Phone: phone,
            Email: email,
        }
    });

    $.ajax({
        url: '/ProjectCreator/Create',
        type: 'POST',
        contentType: 'application/json',
        dataType: "json",
        data: data,
        async: true
    }).done(function (data) {
        console.log(data);
        $('.alert').hide();
        console.log(data);
        if (data.errorCode == 200) {
            let $alertArea = $('.js-create-projectcreator-success');
            $alertArea.html(`Successfully added project creator with fullname: ${data.data.firstname} ${data.data.lastname}`);
            $alertArea.show();
        } else {
            let $failaAlertArea = $('.js-create-projectcreator-alert');
            $failaAlertArea.html(`Error occured during registration of project creator with error: ${data.errorCode} with text: ${data.errorText}`)
            $failaAlertArea.show();
            console.log(data.errorText);
        }
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

$('.js-btn-search-project').on('click', () => {
    $('.js-btn-search-project').attr('disabled', true);
    $('.js-table-search').html('');

    let title = $('.js-search-title').val();
   
    let data = JSON.stringify({
        SearchProjectOptions: {
            title: title   
        }
    });

    $.ajax({
        url: '/project/search',
        type: 'POST',
        contentType: 'application/json',
        data: data
    }).done((projects) => {
        if (projects.length === 0) {
            return;
        }

        projects.forEach(p => {
            let row =
                `<tr>
                    <td>${p.title}</td>
                    <td>${p.budget}</td>
                    <td>${p.deadline}</td>
                    <td><a href="${p.detailsUrl}">More...</a></td>
                </tr>`;

            $('.js-table-search').append(row);
        });
        setTimeout(function () {
            $('.js-btn-search-project').attr('disabled', false);
        }, 300);

    }).fail((xhr) => {
        $('.alert').hide();
        let $alertArea = $('.js-search-project-alert');
        $alertArea.attr("class", "alert alert-danger");
        $alertArea.html(xhr.responseText);
        $alertArea.fadeIn();

        setTimeout(function () {
            $('.js-btn-search-project').attr('disabled', false);
        }, 300);
    });
});