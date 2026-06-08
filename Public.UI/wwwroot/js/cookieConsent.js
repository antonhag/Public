window.cookieConsent = {
    get: function () {
        return document.cookie.includes("cookie_consent=");
    },
    accept: function () {
        const d = new Date();
        d.setFullYear(d.getFullYear() + 1);
        document.cookie = "cookie_consent=true; expires=" + d.toUTCString() + "; path=/";
    },
    decline: function () {
        const d = new Date();
        d.setFullYear(d.getFullYear() + 1);
        document.cookie = "cookie_consent=false; expires=" + d.toUTCString() + "; path=/";
    }
};