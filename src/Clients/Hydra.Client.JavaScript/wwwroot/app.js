function log() { document.getElementById('results').innerText = '';
    Array.prototype.forEach.call(arguments, function (msg) { 
        if (msg instanceof Error) {
            msg = "Error: " + msg.message; 
        }else if (typeof msg !== 'string') {
            msg = JSON.stringify(msg, null, 2);
        }
        document.getElementById('results').innerHTML += msg + '\r\n'; });
}

///the UserManager class from the oidc-client library to manage the OpenID Connect protocol
var config = {
    authority: "http://localhost:5000", // Hydra Identity Server
    client_id: "7d84d81e-b63d-4642-a357-fef5203dc2d8",
    redirect_uri: "http://localhost:5003/callback.html",
    response_type: "code",
    scope: "openid profile hydra-api",
    post_logout_redirect_uri: "http://localhost:5003/index.html"
}

var mgr = new Oidc.UserManager(config);

mgr.getUser().then((user) => {
    user ? log("User logged in", user.profile) : log("User not logged in");
});

var login = () => {
    mgr.signinRedirect();
}

var api = () => {
    mgr.getUser().then((user) => {
        var url = "http://localhost:5001/identity"; // Hydra Auth API
        var xhr = new XMLHttpRequest();
        xhr.open("GET", url);
        xhr.onload = () => log(xhr.status, JSON.parse(xhr.responseText));
        xhr.setRequestHeader("Authorization", "Bearer " + user.access_token);
        xhr.send();
    });
}

var logout = () => {
    mgr.signoutRedirect();
}

document.getElementById("login").addEventListener("click", login, false);
document.getElementById("api").addEventListener("click", api, false)
document.getElementById("logout").addEventListener("click", logout, false);

