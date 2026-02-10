window.auth = {
    login: async function (model) {
        const response = await fetch("/login", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            credentials: "include",
            body: JSON.stringify(model)
        });

        return response.ok;
    },

    logout: async function () {
        const response = await fetch("/logout", {
            method: "POST",
            credentials: "include"
        });

        return response.ok;
    }
};