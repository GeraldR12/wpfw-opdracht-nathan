// projecten in een array zetten en renderen
const projects = [
    {   naam: "TradeWar",
        beschrijving: "TradeWar is plugin die ik heb ontwikkeld met behulp van Java, Paper API, Towny API en SQLLite. Het plugin is een systeem waar met commands je kunt towns en nations tarieven zetten voor trading, sancties en embargoes. Je kunt dit via commands doen en bewaart dit in een SQLLite database. Het plugin is gemaakt voor Minecraft servers die Towny gebruiken.",
        tags: ["Java", "Paper API", "Towny API", "SQLLite"],
        link:"https://github.com/GeraldR12/TradeWar",
        categorie: "Plugin"
    },
    {   naam: "KSCloudHost",
        beschrijving: "Een website die ik heb gebouwd voor een kleine hosting bedrijf genaamd KSCloudHost. De website is gebouwd met HTML, CSS en JavaScript. Het is een statische website die informatie geeft over de diensten van het bedrijf en contactinformatie biedt.",
        tags: ["HTML", "CSS", "JavaScript"],
        link:"https://github.com/GeraldR12/KSCloudHost",
        categorie: "Website"
    },
    {   naam: "Flores-Fuertes",
        beschrijving: "Een schoolproject dat ik en mijn team heb gebouwd voor een veiling bedrijf. De website is gebouwd met HTML, CSS, Javascript en C#. Het is een dynamische website die andere bedrijven hun veiling kan maken en beheren. Het is een project dat we hebben gebouwd voor een schoolopdracht en is niet live.",
        tags: ["HTML", "CSS", "JavaScript", "C#"],
        link:"https://github.com/AnsonM03/Flores-Fuertes",
        categorie: "Website"
    }
];

const projectContainer = document.getElementById("projects-container");

function renderProjects(list){
    projectContainer.textContent = "";
    list.forEach(project => {
        const article = document.createElement("article");
        article.classList.add("projectcard");

        const link = document.createElement("a");
        link.href = project.link;
        link.target = "_blank";
        link.rel = "noopener noreferrer";

        const naam = document.createElement("h3");
        naam.textContent = project.naam;

        const beschrijving = document.createElement("p");
        beschrijving.textContent = project.beschrijving;

        const tagsContainer = document.createElement("span");
        tagsContainer.classList.add("tags-container");
        tagsContainer.textContent = project.tags.join(", ");

        link.appendChild(naam);
        link.appendChild(beschrijving);
        link.appendChild(tagsContainer);

        article.appendChild(link);
        projectContainer.appendChild(article);
    });
}
renderProjects(projects);


//filterknoppen
const filterButtons=document.querySelectorAll(".filter-buttons button");

function  filterProjects(categorie){
    if (categorie === "Alles") {
        renderProjects(projects);
    }
    else {
            const filteredProjects = projects.filter(project =>{
                return project.categorie === categorie;
        });

        renderProjects(filteredProjects);
    }
}

function setActiveButton(gekozenButton) {
    filterButtons.forEach(button => {
        button.setAttribute("aria-pressed", "false");
    });
    gekozenButton.setAttribute("aria-pressed", "true");
}

filterButtons.forEach(button => {
    button.addEventListener("click", () => {
        const gekozenCategorie = button.dataset.categorie;
        filterProjects(gekozenCategorie);
        setActiveButton(button);
    });
});