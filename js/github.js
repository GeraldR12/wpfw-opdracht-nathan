const repoUrl = "https://api.github.com/users/GeraldR12/repos";
const repoStatus = document.getElementById("repo-status");
const repoContainer = document.getElementById("repo-container");

function toonStatus(tekst) {
    repoStatus.textContent = tekst;
}

function renderRepos(repos) {
    repoContainer.textContent = "";
    repos.forEach(repo => {
        const article = document.createElement("article");
        article.classList.add("projectcard");

        const link = document.createElement("a");
        link.href = repo.html_url;
        link.target = "_blank";
        link.rel = "noopener noreferrer";

        const naam = document.createElement("h3");
        naam.textContent = repo.name;

        const beschrijving = document.createElement("p");
        beschrijving.textContent = repo.description || "Geen beschrijving beschikbaar.";

        link.appendChild(naam);
        link.appendChild(beschrijving);
        article.appendChild(link);
        repoContainer.appendChild(article);
    });
}

async function haalReposOp(){
    try{
        toonStatus("Repositories worden opgehaald...");
        const response = await fetch(repoUrl);
        const data = await response.json();

        if (response.ok) {
            toonStatus(`Aantal repositories: ${data.length}`);
            renderRepos(data);
        } else {
            toonStatus(`Fout bij het ophalen van repositories: ${response.status}`);
        }

    } catch (error) {
        console.error("Fout bij het ophalen van de repositories:", error);
        toonStatus("Er is een fout opgetreden bij het ophalen van de repositories.");
    }
}

haalReposOp();