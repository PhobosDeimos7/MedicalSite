window.themeUtils = {
    // Apply a specific theme ('light' or 'dark')
    setTheme: function (theme) {
        if (theme === 'dark') {
            document.documentElement.classList.add('dark');
        } else {
            document.documentElement.classList.remove('dark');
        }
        localStorage.setItem('theme', theme);
    },

    // Toggle between light and dark
    toggleTheme: function () {
        if (document.documentElement.classList.contains('dark')) {
            this.setTheme('light');
        } else {
            this.setTheme('dark');
        }
    },

    // Helper to check current state (returns true if dark)
    isDark: function () {
        return document.documentElement.classList.contains('dark');
    },

    // Initialize: Check localStorage -> System Preference -> Default to Light
    initTheme: function () {
        const storedTheme = localStorage.getItem('theme');
        
        if (storedTheme) {
            this.setTheme(storedTheme);
        } else {
            // Check system preference
            if (window.matchMedia && window.matchMedia('(prefers-color-scheme: dark)').matches) {
                this.setTheme('dark');
            } else {
                this.setTheme('light');
            }
        }
    },
    
    // Explicit getter as requested
    getStoredTheme: function() {
        return localStorage.getItem('theme');
    }
};