// Add ripple effect to buttons
document.querySelectorAll(".btn").forEach((button) => {
  button.addEventListener("click", function (e) {
    // Create ripple element
    const ripple = document.createElement("span");
    ripple.classList.add("ripple");

    // Get click position relative to button
    const rect = button.getBoundingClientRect();
    const size = Math.max(rect.width, rect.height);
    const x = e.clientX - rect.left - size / 2;
    const y = e.clientY - rect.top - size / 2;

    // Position and size ripple
    ripple.style.width = ripple.style.height = `${size}px`;
    ripple.style.left = `${x}px`;
    ripple.style.top = `${y}px`;

    // Add to button
    this.appendChild(ripple);

    // Remove after animation completes
    setTimeout(() => {
      if (ripple.parentNode === this) {
        this.removeChild(ripple);
      }
    }, 600);
  });
});

// Initialize Material Design components
document.addEventListener("DOMContentLoaded", function () {
  // Add focus effects to form controls
  document.querySelectorAll(".form-control").forEach((input) => {
    input.addEventListener("focus", function () {
      this.parentElement.classList.add("focused");
    });

    input.addEventListener("blur", function () {
      if (this.value === "") {
        this.parentElement.classList.remove("focused");
      }
    });
  });
});
