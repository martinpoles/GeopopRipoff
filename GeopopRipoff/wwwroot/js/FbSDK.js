window.fbAsyncInit = function () {
    FB.init({
        appId: '1541569503091986',
        cookie: true,
        xfbml: true,
        version: 'v20.0'
    });

    FB.AppEvents.logPageView();
};

(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement(s); js.id = id;
    js.src = "https://connect.facebook.net/en_US/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));

function checkLoginState() {
    FB.getLoginStatus(function (response) {
        statusChangeCallback(response);
    });
}

function statusChangeCallback(response) {
    if (response.status === 'connected') {
        // Logged into your webpage and Facebook.
        getUserData();
    } else {
        // The person is not logged into your webpage or we are unable to tell.
        console.log('User not authenticated');
    }
}

function getUserData() {
    FB.api('/me', { fields: 'id,name,email' }, function (response) {
        if (response && !response.error) {
            console.log('Successful login for: ' + response.name);
            console.log('Email: ' + response.email);
            console.log('ID: ' + response.id);

            // Chiamata a una funzione per salvare i dati
            saveUserData(response);
        } else {
            console.log('Error fetching user data: ', response.error);
        }
    });
}

function saveUserData(user) {
    // Invia i dati dell'utente al server per salvarli nel database
    fetch('LogSignInOut/SaveUserData', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            FacebookId: user.id,
            Name: user.name,
            Email: user.email
        })
    }).then(response => {
        return response.json();
    }).then(data => {
        console.log('User data saved successfully:', data);
    }).catch(error => {
        console.error('Error saving user data:', error);
    });
}