const form = document.getElementById("contact-form");

const bevestiging = document.getElementById("bevestiging");

form.addEventListener("submit", (event) => {
    event.preventDefault();
    const naamValid = valideerNaam();
    const emailValid = valideerEmail();
    const berichtValid = valideerBericht();

    if (naamValid && emailValid && berichtValid) {
        bevestiging.textContent = "Bedankt voor je bericht!";
        
        form.reset();
    } else {
        bevestiging.textContent = "";
    }
});

function toonFout(veld, melding) {
    const foutElement = document.getElementById(veld.id + "-error");
    foutElement.textContent = melding;
    veld.setAttribute("aria-invalid", "true");
}

function wisFout(veld) {
    const foutElement = document.getElementById(veld.id + "-error");
    foutElement.textContent = "";
    veld.removeAttribute("aria-invalid");
}

const naamVeld = document.getElementById("naam");
function valideerNaam() {
    const waarde = naamVeld.value.trim();

    if (waarde === "") {
        toonFout(naamVeld, "Vul je naam in.");
        return false;
    }

    wisFout(naamVeld);
    return true;
}

const emailVeld = document.getElementById("email");
function valideerEmail() {
    const waarde = emailVeld.value.trim();
    const emailInclude = waarde.includes("@");
    const puntInclude = waarde.includes(".");
    if (waarde === "") {
        toonFout(emailVeld, "Vul je e-mailadres in.");
        return false;
    }
    if (!emailInclude || !puntInclude) {
        toonFout(emailVeld, "Vul een geldig e-mailadres in.");
        return false;
    }

    wisFout(emailVeld);
    return true;
}

const berichtVeld = document.getElementById("bericht");
function valideerBericht() {
    const waarde = berichtVeld.value.trim();
    if (waarde === "") {
        toonFout(berichtVeld, "Vul je bericht in.");
        return false;
    }

    if (waarde.length < 10) {
        toonFout(berichtVeld, "Je bericht moet minimaal 10 tekens bevatten.");
        return false;
    }

    wisFout(berichtVeld);
    return true;
} 