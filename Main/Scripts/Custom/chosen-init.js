function initializeChosen(idioma) {
    if (idioma == 'es') {
        $(".chosen").chosen({
            no_results_text: "No hay resultados para su búsqueda",
            search_contains: true,
            width: '100%'
        });
    } else {
        $(".chosen").chosen({
            no_results_text: "No results for this search",
            search_contains: true,
            width: '100%'
        });
    }
}