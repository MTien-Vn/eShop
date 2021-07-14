import axios from 'axios';
import { baseUrl } from '../../configConnection.json'
// import { HTTPRequest } from '../httpRequest';

const getItems = async(page, limmit) => {
    var res = await axios.get(baseUrl + '/Item/' + page + '/' + limmit);
    return res.data;
}

export default {
    getItems
}