const sidebar = document.getElementById('sidebar');
const toggleBtn = document.getElementById('toggleSidebar');

let isOpen = false;

toggleBtn.onclick = () => {
    if (!isOpen) {
        sidebar.style.left = '0';
        toggleBtn.style.left = '310px';
    } else {
        sidebar.style.left = '-300px';
        toggleBtn.style.left = '10px';
    }
    isOpen = !isOpen;
};

document.addEventListener('click', (e) => {
    if (isOpen && !sidebar.contains(e.target) && !toggleBtn.contains(e.target)) {
        sidebar.style.left = '-300px';
        toggleBtn.style.left = '10px';
        isOpen = false;
    }
});
