document.addEventListener("DOMContentLoaded", function () {
    const form = document.getElementById("form");
    const status = document.getElementById("status");
  
    form.addEventListener("submit", function (e) {
      e.preventDefault();
      const username = document.getElementById("username").value;
      const password = document.getElementById("password").value;
  
      fetch("/Usuarios/Login", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          nome: username,
          senha: password,
        }),
      })
        .then((response) => {
          if (!response.ok) {
            throw new Error("Erro ao fazer login. Por favor, tente novamente mais tarde.");
          }
          return response.json();
        })
        .then((data) => {
          if (data.success) {
            window.location.href = "/dashboard.html";
          } else {
            status.textContent = "Credenciais inválidas. Por favor, tente novamente.";
          }
        })
        .catch((error) => {
          console.error("Erro ao fazer login:", error);
          status.textContent = error.message;
        });
    });
  });
  