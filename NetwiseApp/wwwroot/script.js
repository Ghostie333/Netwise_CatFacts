const factsList = document.getElementById("facts");
const statusEl = document.getElementById("status");
const btn = document.getElementById("newFactBtn");

function factText(f) {
    return f.fact ?? f.Fact ?? "";
}

function renderFact(f) {
    const li = document.createElement("li");
    li.textContent = factText(f);
    factsList.prepend(li);
}

async function loadFacts() {
    statusEl.textContent = "Ładowanie...";
    try {
        const res = await fetch("/api/facts");
        if (!res.ok) throw new Error(res.status);
        const data = await res.json();
        factsList.innerHTML = "";
        data.forEach(renderFact);
        statusEl.textContent = "";
    } catch {
        statusEl.textContent = "Błąd ładowania faktów.";
    }
}

btn.addEventListener("click", async () => {
    statusEl.textContent = "Pobieranie...";
    try {
        const res = await fetch("/api/facts", { method: "POST" });
        if (!res.ok) throw new Error(res.status);
        const fact = await res.json();
        renderFact(fact);
        statusEl.textContent = "";
    } catch {
        statusEl.textContent = "Błąd pobierania faktu.";
    }
});

loadFacts();
