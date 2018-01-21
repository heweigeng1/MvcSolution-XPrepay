import { query as queryUsers, queryCurrent, userSearch, index, resetPassword } from '../services/user';
import { checkResponse, messagePut } from '../utils/errPut'
export default {
  namespace: 'user',

  state: {
    data: {
      list: [],
      pagination: {},
    },
    loading: false,
    currentUser: {},
    modalVisible: false,
    modal: { title: "", data: {} }
  },

  effects: {
    *fetch(_, { call, put }) {
      yield put({
        type: 'changeLoading',
        payload: true,
      });
      const response = yield call(queryUsers);
      yield put({
        type: 'save',
        payload: response,
      });
      yield put({
        type: 'changeLoading',
        payload: false,
      });
    },
    *fetchCurrent(_, { call, put }) {
      const response = yield call(queryCurrent);
      yield put({
        type: 'saveCurrentUser',
        payload: response,
      });
    },
    *index(_, { call, put }) {
      const response = yield call(index);
      //是否正确返回数据.根据错误code 跳转页面
      yield call(checkResponse, { response, put });
      yield put({
        type: 'loadList',
        payload: response.Value,
      })
    },
    *userSearch({ payload }, { call, put }) {
      const response = yield call(userSearch, payload);

      //是否正确返回数据.根据错误code 跳转页面
      yield call(checkResponse, { response, put });
      yield put({
        type: 'loadList',
        payload: response.Value,
      })
    },
    *hideVisible(_, { call, put }) {
      yield put({
        type: 'hideModal',
      })
    },

    *changeModalVisible({ payload }, { call, put }) {
      console.log(payload)
      yield put({
        type: 'changeVisible',
        payload: payload
      })
    },
    *updateModalData({ payload }, { call, put }) {
      yield put({
        type: 'updateModaldata',
        payload: payload
      })
    },
    *resetPassword({ payload }, { call, put }) {
      const response = yield call(resetPassword, payload);
      yield call(checkResponse, { response, put });
      yield call(messagePut, { response, put });
    },
  },

  reducers: {
    save(state, action) {
      return {
        ...state,
        list: action.payload,
      };
    },
    changeLoading(state, action) {
      return {
        ...state,
        loading: action.payload,
      };
    },
    saveCurrentUser(state, action) {
      return {
        ...state,
        currentUser: action.payload,
      };
    },
    changeNotifyCount(state, action) {
      return {
        ...state,
        currentUser: {
          ...state.currentUser,
          notifyCount: action.payload,
        },
      };
    },
    hideModal(state, action) {
      return {
        ...state,
        modalVisible: !state.modalVisible,
      }
    },
    changeVisible(state, { payload }) {
      return {
        ...state,
        modalVisible: !state.modalVisible,
        modal: {
          title: payload.title,
          data: payload.data
        }
      }
    },
    updateModaldata(state, { payload }) {
      console.log(payload)
      return {
        ...state,
        modal: {
          data: payload,
        }
      }
    },
    loadList(state, { payload }) {
      return {
        ...state,
        data: {
          list: payload.Value,
          pagination: {
            total: payload.TotalCount,
            pageSize: payload.PageSize,
            current: payload.PageIndex,
          }
        },
        loading: false,
      }
    },
  },
};
