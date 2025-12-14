window.themeManager = {
    init: function () {
        const storedTheme = localStorage.getItem('theme');
        const systemPrefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;

        if (storedTheme === 'dark' || (!storedTheme && systemPrefersDark)) {
            document.documentElement.classList.add('dark');
        } else {
            document.documentElement.classList.remove('dark');
        }
    },
    toggle: function () {
        const html = document.documentElement;
        if (html.classList.contains('dark')) {
            html.classList.remove('dark');
            localStorage.setItem('theme', 'light');
            return false;
        } else {
            html.classList.add('dark');
            localStorage.setItem('theme', 'dark');
            return true;
        }
    },
    isDark: function () {
        return document.documentElement.classList.contains('dark');
    }
};

// GLOBAL STORAGE HELPER (Fixes the crash)
window.appStorage = {
    save: function (key, data) {
        localStorage.setItem(key, data);
    },
    load: function (key) {
        return localStorage.getItem(key);
    }
};

window.themeManager.init();