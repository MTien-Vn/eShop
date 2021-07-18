import axios from 'axios';
import { baseUrl } from '../../configConnection.json'
// import { HTTPRequest } from '../httpRequest';

const getTotalCostRevenueProfit = async(year) => {
    var res = await axios.get(baseUrl + '/Statistic/' + year);
    return res.data;
}

export default {
    getTotalCostRevenueProfit
}