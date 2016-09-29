$(function () {

    var db;

    var categoryData = [
        { Name: 'Greeting' }, { Name: 'Shopping' }, { Name: 'Colors' }, { Name: 'Numbers' }, { Name: 'Basic' }
    ];

    var itemData = [
        { English: 'Hello', Myanmar: 'Nay kaung lar', Myanglish: 'Nay kaung lar', CategoryId: 1 },
        { English: 'How are you', Myanmar: 'Nay kaung lar', Myanglish: 'Nay kaung lar', CategoryId: 1 },
        { English: 'Good Morning', Myanmar: 'Nay kaung lar', Myanglish: 'Nay kaung lar', CategoryId: 1 },
        { English: 'Good Afternoon', Myanmar: 'Nay kaung lar', Myanglish: 'Nay kaung lar', CategoryId: 1 }
    ];

    var req = indexedDB.open("testDb", 2);

    req.onerror = function (e) {
        toastr.info(e.target.errorCode);
    };

    req.onsuccess = function (e) {
        db = this.result;
        toastr.info('database opened or created');

        populateData(e);
    };

    req.onupgradeneeded = function (e) {
        toastr.info('upgrade needed');

        populateData(e);
    };

    function populateData(e) {

        var catStore = e.currentTarget.result.createObjectStore('category', { keyPath: 'Id', autoIncrement: true });

        catStore.createIndex('Name', 'Name', { unique: false });

        var itemStore = e.currentTarget.result.createObjectStore('item', { keyPath: 'Id', autoIncrement: true });

        itemStore.createIndex('English', 'English', { unique: false });
        itemStore.createIndex('Myanmar', 'Myanmar', { unique: false });
        itemStore.createIndex('Myanglish', 'Myanglish', { unique: false });
        itemStore.createIndex('CategoryId', 'CategoryId', { unique: false });

        catStore.transaction.oncomplete = function (e) {
            var categoryObjectStore = db.transaction("category", "readwrite").objectStore("category");
            for (var i in categoryData) {
                categoryObjectStore.add(categoryData[i]);
            }
        }

        itemStore.transaction.oncomplete = function (e) {
            var itemObjectStore = db.transaction("item", "readwrite").objectStore("item");
            for (var i in itemData) {
                itemObjectStore.add(itemData[i]);
            }
        }
    }








});