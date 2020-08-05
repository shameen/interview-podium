module.exports = {
    /** POST JSON to a URL, with response parsing + checking.
     * Returns a Promise of the JSON-parsed response.
     */
    PostJsonToUrl: (json, url) => {
        const requestBody = JSON.stringify(json);

        let hasError = false;
        let errorMessage = "";
        const onError = (err) => Promise.reject(err);
        
        return fetch(url, {
            method: 'POST',
            body: requestBody,
            headers: new Headers({
                "Content-Type": "application/json",
                "Content-Length": requestBody.length
            }),
            cache: 'no-cache'
        })
        .then(response => {
            if (response.ok === false) {
                hasError = true;
                errorMessage += `Sorry, something went wrong: ${response.status} ${response.statusText}`;
            }
            try {
                return response.json();
            }
            catch (err) {
                hasError = true;
                errorMessage += "\n"+err.message;
            }
        }, (reason) => { errorMessage += "Unexpected error: "+reason })
        .then(data => {
            if (data.errors) {
                //two types of errors, asp.net built-in is an object, and API custom errors is an array
                if (Array.isArray(data.errors)) {
                    errorMessage += data.errors.join("\n");
                }
                else if (typeof data.errors === "object") {
                    for (const item in data.errors)
                        errorMessage += `\n${data.errors[item]}`
                }
            }
            if (hasError) {
                //Pop-up alert, and reject the promise
                throw alert(errorMessage);
            }
            console.log("http response: ",data);
            return data;
        }, onError);
    }
}