const leesMeerButtons = document.querySelectorAll(".lees-meer-knop");

function toggleBlog(button) {
    const tekstId = button.getAttribute("aria-controls");
    const extraTekst = document.getElementById(tekstId);

    const isExpanded = button.getAttribute("aria-expanded") === "true";

    const wordOpen = !isExpanded;

    if(wordOpen) {
        extraTekst.removeAttribute("hidden");
        button.textContent = "Lees minder";
    } else {
        extraTekst.setAttribute("hidden", "");
        button.textContent = "Lees meer";
    }

    button.setAttribute("aria-expanded", wordOpen ? "true" : "false");
}

leesMeerButtons.forEach(button => {
    button.addEventListener("click", () => {
        toggleBlog(button);
    });
});