// Create _ Open Database and put initial data

var mytest = {};
window.indexedDB = window.indexedDB || window.webkitIndexedDB || window.mozIndexedDB;

if ('webkitIndexedDB' in window) {
    window.IDBTransaction = window.webkitIDBTransaction;
    window.IDBKeyRange = window.webkitIDBKeyRange;
};

mytest.indexedDB = {};
mytest.indexedDB.db = null;

mytest.indexedDB.onerror = function (e) {
    toastr.info(e);
};

mytest.indexedDB.open = function (e) {

    var version = 1;
    var request = indexedDB.open("mytest", version);

    request.onupgradeneeded = function (e) {
        var db = e.target.result;

        e.target.transaction.onerror = mytest.indexedDB.onerror;

        if (db.objectStoreNames.contains("test")) {
            db.deleteObjectStore("test");
        }

        var store = db.createObjectStore("test", { keyPath: "timeStamp" });
    };

    request.onsuccess = function (e) {
        mytest.indexedDB.db = e.target.result;
        mytest.indexedDB.getAlltests();
    }

    request.onerror = mytest.indexedDB.onerror;
};



function init() {
    mytest.indexedDB.open();
}


window.addEventListener("DOMContentLoaded", init, false);