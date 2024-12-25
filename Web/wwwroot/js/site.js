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
    _ = new Chart(offscreen, chart.config);

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
    }, 0); // Minimum time required?
}


window.tdb = function(dbName, dbVersion, storeName) {
    this.db;
    this.dbName = dbName;
    this.dbVersion = dbVersion;
    this.storeName = storeName;
    
    this.openDB = function(callback = (() => { })) {
        if (!window.indexedDB) {
            callback({ message: 'Unsupported indexedDB' });
        }

        let request = window.indexedDB.open(this.dbName, this.dbVersion);

        request.onsuccess = e => {
            this.db = request.result;
        };
        request.onerror = e => callback(e.target.error);
        request.onupgradeneeded = e => {
            this.db = e.target.result;
            this.db.onabort = e2 => callback(e2.target.error);
            this.db.error = e2 => callback(e2.target.error);
            
            this.db.createObjectStore(storeName);
        };
    }

    this.deleteDB = function() {
        if (window.indexedDB) {
            window.indexedDB.deleteDatabase(this.dbName);
        }
    }

    this.deleteStore = function(storeName, callback = (() => { })) {
        if (this.db) {
            this.db.deleteObjectStore();
            this.db.oncomplete = e => callback(e.target.result);
            this.db.onabort = e => callback(e.target.error);
            this.db.error = e => callback(e.target.error);
        }
    }

    this.upsert = function (storeName, key, data, callback = (() => { })) {
        if (this.db && data) {
            let transaction = this.db.transaction([storeName], 'readwrite');
            transaction.onabort = te => callback(te.target.error);
            transaction.onerror = te => callback(te.target.error);

            let request = transaction.objectStore(storeName).put(data, key);
            request.onerror = e => callback(e.target.error);
            request.onsuccess = e => callback(e.target.result);
        }
    }

    this.get = function(storeName, key, callback = (() => { })) {
        if (this.db && key) {
            let request = this.db.transaction([storeName]).objectStore().get(key)
            request.onerror = e => callback(e.target.error);
            request.onsuccess = e => callback(e.target.result);
        }
    }

    this.getAll = function(storeName, callback = (() => { })) {
        if (this.db) {
            let request = this.db.transaction(storeName).objectStore(storeName).openCursor(null, 'next');
            let results = [];
            request.onsuccess = e => {
                let cursor = e.target.result;
                if (cursor) {
                    console.log("Key:" + cursor.key + " Value:" + cursor.value);
                    results.push({ [cursor.key]: cursor.value });
                    cursor.continue();
                } else {
                    callback(results);
                }
            };
            request.onerror = e => callback(e.target.error);
        }
    }

    this.remove = function(storeName, key, callback = (() => { })) {
        if (this.db) {
            let request = this.db.transaction([storeName], 'readwrite').objectStore(storeName).delete(key);
            request.onerror = e => callback(e.target.error);
            request.onsuccess = e => callback(e.target.result);
        }
    }

    this.clear = function(storeName, callback = (() => { })) {
        if (this.db) {
            let request = this.db.transaction([storeName], 'readwrite').objectStore(storeName).clear();
            request.onerror = e => callback(e.target.error);
            request.onsuccess = e => callback(e.target.result);
        }
    }

    this.count = function(storeName, callback = (() => { })) {
        if (this.db) {
            let request = this.db.transaction([storeName]).objectStore(storeName).count();
            request.onerror = e => callback(e.target.error);
            request.onsuccess = e => callback(e.target.result);
        }
    }

    return this;
}