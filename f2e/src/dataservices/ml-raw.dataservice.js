import {
    ApiHelper
} from '../util/api.js';

import {
    API
} from '../constants.js';

import {
    APP_CONFIG
} from '../config.js';

export const MlDataService = {
    Create: async (data) => {
        const api = APP_CONFIG.API_ENDPOINT + API.ML;
        const requestBody = {
            ...data
        };
        return ApiHelper.sendRequest(api, {
            method: 'POST',
            body: JSON.stringify(requestBody)
        });
    }
};
