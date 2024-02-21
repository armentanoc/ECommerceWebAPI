
function fetchData(url, callback) {
    const requestOptions = {
        method: "GET",
        redirect: "follow"
    };

    fetch(url, requestOptions)
        .then((response) => response.json())
        .then((result) => {
            callback(result);
        })
        .catch((error) => {
            callback({ error: "Erro na requisição" });
        });
}

function getAllProducts() {
    fetchData("http://localhost:5500/api/product", (result) => {
        displayResult(result);
    });
}

function getAllSales() {
    fetchData("http://localhost:5500/api/sale", (result) => {
        displayResult(result);
    });
}

function getAllRefunds() {
    fetchData("http://localhost:5500/api/refund", (result) => {
        displayResult(result);
    });
}

function getAllExchanges() {
    fetchData("http://localhost:5500/api/exchange", (result) => {
        displayResult(result);
    });
}

function filterProductsByName() {
    const productName = document.getElementById("productName").value;

    if (productName) {
        fetchData(`http://localhost:5500/api/product/filter?name=${encodeURIComponent(productName)}`, (result) => {
            displayResult(result);
        });
    } else {
        displayResult({ message: "No products found." });
    }
}

function displayResult(result) {
    const resultSection = document.getElementById("result");
    
    if (result && !result.error) {
        const formattedResult = JSON.stringify(result, null, 2);
        resultSection.innerHTML = `<pre>${formattedResult}</pre>`;
    } else if (result && result.message) {
        resultSection.innerHTML = `<p>${result.message}</p>`;
    } else {
        resultSection.innerHTML = `<p>No data available.</p>`;
    }
}
