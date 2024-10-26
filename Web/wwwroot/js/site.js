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

window.wrap = (str, limit) => {
    if (!str) {
        return str;
    }

    const words = str.split(" ");
    let aux = []
    let concat = []

    for (let i = 0; i < words.length; i++) {
        concat.push(words[i])
        let join = concat.join(' ')
        if (join.length > limit) {
            aux.push(join)
            concat = []
        }
    }

    if (concat.length) {
        aux.push(concat.join(' ').trim())
    }

    return aux;
}

window.uploadChart = function uploadChart(chart, width, height, email, token, type, name) {
    const offscreen = new OffscreenCanvas(width, height);

    // Since the original chart was already created we don't need to deep clone.
    chart.config.options.animation = { duration: 0 }; // Disable animation.
    const chartClone = new Chart(offscreen, chart.config);

    // Let the charts finish drawing.
    setTimeout(async () => {
        const blob = await offscreen.convertToBlob();

        const data = new FormData();
        data.append("image", blob);
        data.append("type", type);
        data.append("email", email);
        data.append("token", token);
        if (name) {
            data.append("name", name);
        }

        fetch("/api/User/UploadImage", {
            method: "POST",
            body: data,
        });
        
        //const reader = new FileReader()
        //reader.onload = (e) => {
        //    console.debug({ reader.result })
        //}
        //reader.readAsDataURL(blob) 
    }, 100); // Minimum time required?
}