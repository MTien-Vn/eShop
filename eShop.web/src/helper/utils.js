const converDateToString = (data) => {
    if (data === undefined) {
        return 'undefined date';
    }
    // var mm = data.getMonth();
    // var dd = data.getDate();

    // return [data.getFullYear(),
    //     (mm > 9 ? '' : '0') + mm,
    //     (dd > 9 ? '' : '0') + dd
    // ].join('');
    return data.split('T')[0];
};

const convertShift = (data) => {
    if (data === undefined) {
        return 'undefined shift code';
    }
    switch (data) {
        case 1:
            return 'morning';
        case 2:
            return 'afternoon';
        case 3:
            return 'evening';
        default:
            break;
    }
}

const converMoneyToString = (data) => {
    if (data === undefined) {
        return 'iundefined salary';
    }
    var rs = data.toFixed(1).replace(/\d(?=(\d{3})+\.)/g, '$&,');
    return rs.toString();
}

export default {
    converDateToString,
    convertShift,
    converMoneyToString
}