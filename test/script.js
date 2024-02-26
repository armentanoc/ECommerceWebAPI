function getDataFromStorage(key) {
    const data = localStorage.getItem(key);
    return data ? JSON.parse(data) : null;
}

function saveDataToStorage(key, data) {
    localStorage.setItem(key, JSON.stringify(data));
}

function fetchData(url, options, callback) {
    fetch(url, options)
        .then((response) => response.json())
        .then((result) => {
            callback(result);
        })
        .catch((error) => {
            console.error("Error in the request:", error);
            callback({ error: "Error in the request" });
        });
}

function displayResult(result, resultSectionId) {

    const resultSection = document.getElementById(resultSectionId);

    if (result && !result.error) {
        const formattedResult = JSON.stringify(result, null, 2);
        resultSection.innerHTML = `<pre>${formattedResult}</pre>`;
    } else if (result && result.message) {
        resultSection.innerHTML = `<p>${result.message}</p>`;
    } else if (result && result.error) {
        resultSection.innerHTML = `<p>Error: ${JSON.stringify(result.error, null, 2)}</p>`;
    } else {
        resultSection.innerHTML = `<p>No data available.</p>`;
    }
}

function getAllProducts() {
    fetchData("http://localhost:5500/api/product", { method: "GET" }, (result) => {
        displayResult(result, "result");
    });
}

function getAllSales() {
    fetchData("http://localhost:5500/api/sale", { method: "GET" }, (result) => {
        displayResult(result, "result");
    });
}

function getAllRefunds() {
    fetchData("http://localhost:5500/api/refund", { method: "GET" }, (result) => {
        displayResult(result, "result");
    });
}

function getAllExchanges() {
    fetchData("http://localhost:5500/api/exchange", { method: "GET" }, (result) => {
        displayResult(result, "result");
    });
}



function getAllProductSales() {
    fetchData("http://localhost:5500/api/productSale", { method: "GET" }, (result) => {
        displayResult(result, "result");
    });
}

function getAllProductExchanges() {
    fetchData("http://localhost:5500/api/productExchange", { method: "GET" }, (result) => {
        displayResult(result, "result");
    });
}

function filterProductsByName() {
    const productName = document.getElementById("productNameToFilter").value;

    if (productName) {
        fetchData(`http://localhost:5500/api/product/filter?name=${encodeURIComponent(productName)}`, { method: "GET" }, (result) => {
            displayResult(result, "result");
        });
    } else {
        displayResult({ message: "No products found." }, "result");
    }
}

function submitProductForm() {
    const productName = document.getElementById("productName").value;
    console.log(productName);
    const productPrice = document.getElementById("productPrice").value;
    const productQuantity = document.getElementById("productQuantity").value;
    const productDescription = document.getElementById("productDescription").value;

    const productData = {
        Name: productName,
        Price: parseFloat(productPrice),
        Quantity: parseInt(productQuantity),
        Description: productDescription
    };

    const requestOptions = {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(productData),
    };

    fetchData("http://localhost:5500/api/product", requestOptions, (result) => {
        displayResult(result, "productResult");
    });
}


function submitSaleForm() {
    const saleProductId = document.getElementById("saleProductId").value;
    const newProductIdsArray = saleProductId.split(',').map(part => parseInt(part.trim()));

    const saleData = {
        ProductIds: newProductIdsArray,
    };

    const requestOptions = {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(saleData),
    };

    fetchData("http://localhost:5500/api/sale", requestOptions, (result) => {
        displayResult(result, "saleResult");
    });
}


function submitRefundForm() {
    event.preventDefault();
    const saleId = document.getElementById("refundSaleId").value;

    const refundData = {
        SaleId: parseInt(saleId),
    };

    const requestOptions = {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(refundData),
        redirect: 'manual',
    };

    fetchData("http://localhost:5500/api/refund", requestOptions, (result) => {
        displayResult(result, "refundResult");
    });
    return false;
}

function submitExchangeForm() {
    const saleId = document.getElementById("exchangeSaleId").value;
    const newProductId = document.getElementById("exchangeNewProductId").value;
    const newProductIdsArray = newProductId.split(',').map(part => parseInt(part.trim()));

    const exchangeData = {
        SaleId: parseInt(saleId),
        ProductIds: newProductIdsArray
    };

    const requestOptions = {
        method: "POST",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(exchangeData),
    };

    fetchData("http://localhost:5500/api/exchange", requestOptions, (result) => {
        displayResult(result, "exchangeResult");
    });
}

function getProductDetails() {
    const updateProductId = document.getElementById("updateProductId").value;

    fetchData(`http://localhost:5500/api/product/${updateProductId}`, { method: "GET" }, (result) => {
        if (result && !result.error) {
            displayProductDetails(result);
        } else {
            displayResult({ message: "Produto não encontrado." }, "updateProductResult");
        }
    });
}

function displayProductDetails(product) {
    document.getElementById("updateProductName").value = product.name;
    document.getElementById("updateProductPrice").value = product.price;
    document.getElementById("updateProductQuantity").value = product.quantityRemaining;
    document.getElementById("updateProductDescription").value = product.description;

    document.getElementById("productDetails").style.display = "block";
}

function submitUpdateProductForm() {
    const updateProductId = document.getElementById("updateProductId").value;
    const updateProductName = document.getElementById("updateProductName").value;
    const updateProductPrice = document.getElementById("updateProductPrice").value;
    const updateProductQuantity = document.getElementById("updateProductQuantity").value;
    const updateProductDescription = document.getElementById("updateProductDescription").value;

    const updatedProductData = {
        Name: updateProductName,
        Price: parseFloat(updateProductPrice),
        Quantity: parseInt(updateProductQuantity),
        Description: updateProductDescription
    };

    const requestOptions = {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(updatedProductData),
    };

    fetchData(`http://localhost:5500/api/product/${updateProductId}`, requestOptions, (result) => {
        displayResult(result, "updateProductResult");
    });
}


