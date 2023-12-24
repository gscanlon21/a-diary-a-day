jQuery.fn.cleanWhitespace = function () {
    this.contents().filter(function () {
        return (this.nodeType == 3 && !/\S/.test(this.nodeValue));
    }).remove();

    return this;
}

// Alert dismissing for bootstrap. I'm not including their JS.
$("[data-dismiss]").each((i, elem) => elem.addEventListener('click', (e) => {
    const parent = $(elem).parent(elem.dataset.dismiss);
    const grandParent = parent.parent();
    parent.remove();
    grandParent.cleanWhitespace();
}))

window.uploadChart = function uploadChart(chart, width, height, email, token, type) {
    const offscreen = new OffscreenCanvas(width, height);
    const chartDuplicate = new Chart(offscreen, chart.config);
    setTimeout(async () => {
        const blob = await offscreen.convertToBlob();
        const form = new FormData();
        const request = new XMLHttpRequest();
        form.append("image", blob);
        form.append("type", type);
        form.append("email", email);
        form.append("token", token);
        request.open("POST", "/api/User/UploadImage", true);
        request.send(form);
        
        //const reader = new FileReader()
        //reader.onload = (e) => {
        //    console.debug({ reader.result })
        //}
        //reader.readAsDataURL(blob) 
    }, 1000);
}