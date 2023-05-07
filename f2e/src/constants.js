import { APP_CONFIG } from './config.js';

export const RESPONSE_STATUS = {
    OK: 'OK',
    FAILED: 'FAILED'
};

export const ERROR_KEYS = {
    SIGN_IN_BY_OTHER_WAY: 'SIGN_IN_BY_OTHER_WAY'
};

export const API = {
    STRAWBERRIES: 'strawberries',
    STRAWBERRY: 'strawberries/{id}',
    STRAWBERRY_LOGS: 'strawberries/{strawberryId}/logs',
    STRAWBERRY_LOG: 'strawberries/{strawberryId}/logs/{id}',
    DISEASES: 'universal/diseases',
    ML: 'ml',
    FILES: 'files'
};

