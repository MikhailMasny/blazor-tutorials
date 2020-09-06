function useAlert() {
    alert("Yes, you run it");
}

function usePromt(querstion) {
    return prompt(querstion);
}

function setElementTextById(id, text) {
    document.getElementById(id).innerText = text;
}

function focusOnElement(element) {
    element.focus();
}

function giveMeRandomInt(maxValue) {
    DotNet.invokeMethodAsync('Masny.Blazor.ServerSide', 'GenerateRandomInt', maxValue)
        .then(result => {
            setElementTextById('randomNumber', result);
        });
}
