import { routerRedux } from 'dva/router';
//获取接口
import { getRoles } from '../services/testOne';

export default {
    namespace: 'role',

    state: {
        list: [],
        loading: true,
    },
    effects: {
        *getRoles({ payload }, { call, put }) {
            const response = yield call(getRoles);
            //console.log(response);
            yield put({
                type: 'Init',
                payload: response,
            })
        },
    },
    reducers: {
        Init(state, { payload }) {
            console.log(payload)
            return {
                ...state,
                list: payload,
                loading:false,
            }
        }
    }
}