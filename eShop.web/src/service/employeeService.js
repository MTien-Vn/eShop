import axios from 'axios';
import { baseUrl } from '../configConnection.json'

const getEmployee = async(page, limmit) => {
    var rs = await axios.get(baseUrl + '/Employee/' + page + '/' + limmit);
    var response = rs.data;
    if (response.misaCode !== 200) {
        //location.reload(true);
        alert(response.messenger);
        return;
    }
    return response.data;
}

export default {
    getEmployee
}