/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,ts,scss,css}"],
  theme: {
    extend: {
      colors: {
        primary: '#FDFFFF',
        'primary-black': '#0A0908',
      },
      screens: {
        'custom950': '950px',
        'custom868': '868px',
        'custom1168': '1168px',
        'custom428': '428px',
        'custom376': '376px',
      },
    },
  },
  plugins: [],
}