import Vue from 'vue';
import Vuex from 'vuex';

import { alert } from './modules/alert';
import { account } from './modules/account';

Vue.use(Vuex);

export const store = new Vuex.Store({
    modules: {
        alert,
        account
    }
});