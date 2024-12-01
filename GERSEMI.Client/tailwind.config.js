/** @type {import('tailwindcss').Config} */
module.exports = {
  content: ["./src/**/*.{html,ts,scss,css}"],
  theme: {
    extend: {
      colors: {
        primary: '#FDFFFF',
      },
      screens: {
        'custom950': '950px',
      },
    },
  },
  plugins: [],
}