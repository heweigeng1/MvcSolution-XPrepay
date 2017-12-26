import React, { PureComponent } from 'react';
import { connect } from 'dva';
import { Table, Row, Col, Card, Form, Input, Select, Icon, Button, Dropdown, Menu, InputNumber, DatePicker, Modal, message } from 'antd';
//import StandardTable from '../../components/StandardTable';
import PageHeaderLayout from '../../layouts/PageHeaderLayout';

import styles from './TableList.less';

@connect(state => ({
    role: state.role,
}))

export default class RoleTable extends PureComponent {
    state = {
        data: [],
        pageIndex: 1,
        pageSize: 10
    }
    componentDidMount() {
        const { dispatch } = this.props;
        dispatch({
          type: 'role/getRoles',
        });
      }
    getRole = () => {
        this.props.dispatch({
            type: 'role/getRoles',
            payload: {
                list: this.state.data
            }
        })
    }
    render() {
        const columns = [
            {
                title: '编号',
                dataIndex: 'No',
            },
            {
                title: '权限名',
                dataIndex: 'RoleName'
            },
            {
                title: '状态',
                dataIndex: 'Status'
            },
            {
                title: '操作',
                render: () => (
                    <div>
                        <a href="">查看</a>
                        <a href="">删除</a>
                    </div>
                ),
            }
        ];
        const paginationProps = {
            showSizeChanger: true,
            showQuickJumper: true,
            pagination: { total: 1, pageSize: 10, current: 1 },
        };
        
        const { role } = this.props;
        console.log(role)
        return (
            <div>
                <Table
                    loading={role.loading}
                    dataSource={role.list}
                    pagination={paginationProps}
                    columns={columns}
                />
            </div>

        )
    }
}