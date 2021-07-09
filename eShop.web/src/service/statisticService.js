import axios from 'axios';
import { baseUrl } from '../configConnection.json'

const statisticTotalAmountByMonth = async(month) => {
    var res = await axios.get(baseUrl + '/statisticTotalAmountByMonth/' + month);
    return res.data;
}

export default {
    statisticTotalAmountByMonth
}