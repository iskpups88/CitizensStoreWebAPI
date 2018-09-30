Ext.define('Classes.DisableCitizen', {
    extend: 'Classes.Citizen',
    config: {
        category: 1
    },
    constructor: function (category, name, surname, patronymic) {
        this.initConfig();
        if (category)
            this.setCategory(category);
        this.callParent([name, surname, patronymic]);
    },

    getInfo: function () {
        alert("Полное имя : " + this.name + " " + this.surname + " " + this.patronymic + " " + this.category);
    }

});