Ext.define('Classes.Citizen', {
    //name: 'Иван',
    //surname: 'Иванов',
    //patronymic: 'Иванович',

    config: {
        name: 'Иван',
        surname: 'Иванов',
        patronymic: 'Иванович'
    },

    constructor: function (name, surname, patronymic) {
        this.initConfig();
        if (name)
            this.setName(name);
        if (surname)
            this.setSurname(surname);
        if (patronymic)
            this.setPatronymic(patronymic);
        this.self.instanceCount++;
    },
    //constructor: function (config) {
    //    this.initConfig(config);
    //    this.self.instanceCount++;
    //},
    statics: {
        instanceCount: 0,
        // статический метод, возвращающий объект класса
        factory: function (name, surname, patronymic) {
            return new this(name, surname, patronymic);
        }
    },
   

    applyName: function (value) {
        if (value == 'Дмитрий') {
            console.log("Недопустимое имя!");
        } else {
            return this.name = value;
        }
    },

    getInfo: function () {
        alert("Полное имя : " + this.name + " " + this.surname + " " + this.patronymic);
    }
});