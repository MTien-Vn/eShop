import axios from 'axios';
import { baseUrl } from '../../configConnection.json'
// import { HTTPRequest } from '../httpRequest';

const getInvoices = async(page, limmit) => {
    var res = await axios.get(baseUrl + '/Invoice/' + page + '/' + limmit);
    return res.data;
}

export default {
    getInvoices
}