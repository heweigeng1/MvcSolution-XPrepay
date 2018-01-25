import React, { PureComponent } from 'react';
import { connect } from 'dva';
import moment from "moment";
import { Popconfirm, Table, Row, Col, Card, Form, Input, Select, Icon, Button, Dropdown, Menu, InputNumber, DatePicker, Modal, message, Divider } from 'antd';
import PageHeaderLayout from '../../layouts/PageHeaderLayout';
import AdminModal from './OrdinaryUserModal';
import styles from '../List/TableList.less';
import style from'./AdminList.less';       

const FormItem = Form.Item;
const getValue = obj => Object.keys(obj).map(key => obj[key]).join(',');

@connect(state => ({
    user: state.user,
}))
@Form.create()


export default class OrdinaryUserList extends PureComponent {

    state = {
        selectedRows: [],
        formValues: {},
    }
    //初始化时加载表格数据.
    componentDidMount() {
        const { dispatch } = this.props;
        dispatch({
            type: 'user/index',
        })
    }
    tableChanger = (pagination, filtersArg, sorter) => {
        const { dispatch } = this.props;
        //查询选项
        const { formValues } = this.state;
        //勾选项
        const filters = Object.keys(filtersArg).reduce((obj, key) => {
            const newObj = { ...obj };
            newObj[key] = getValue(filtersArg[key]);
            return newObj;
        }, {});
        dispatch({
            type: "user/userSearch",
            payload: {
                ...formValues,
                pagination: {
                    currentPage: pagination.current,
                    pageSize: pagination.pageSize,
                    sorter: sorter.field,
                    sortDirection: sorter.order
                },
            }
        })
    }
    //搜索按钮
    search = (e) => {
        const { dispatch, form } = this.props;
        e.preventDefault();
        form.validateFields((err, fieldsValue) => {
            if (err) return;
            const values = {
                ...fieldsValue,
            }
            this.setState({
                formValues: values,
            });
            dispatch({
                type: 'user/userSearch',
                payload: {
                    ...values,
                    pagination: {}
                }
            })
        })
    }
    // 事件 传参方法
    resetPassword = (record) => {
        console.log(record)
        const { dispatch } = this.props;
        dispatch({
            type: 'user/resetPassword',
            payload: {id:record.key}
        })
    }
    deleteUser = (record, event) => {
       /*  console.log(record); */
    }
    //显示添加模态框
    changeVisible = (record) => {
        console.log(record)
        const { dispatch } = this.props;
        if (record != undefined) {
            dispatch({
                type: 'user/changeModalVisible',
                payload: {
                    title: "编辑-" + record.NickName,
                    data: record,
                }
            })
        } else {
            dispatch({
                type: 'user/changeModalVisible',
                payload: {
                    title: "添加用户",
                    data: {}
                }
            })
        }

    }
    hideModal=()=>{
        const { dispatch } = this.props;
        dispatch({
            type: 'user/hideVisible',
        })
    }
    render() {
        const { data: { list, pagination }, loading, modalVisible } = this.props.user;
        const { getFieldDecorator, getFieldsError, getFieldError, isFieldTouched } = this.props.form;
        const paginationProps = {
            //显示每页显示多少条数据
            showSizeChanger: true,
            //快速跳转到第几页
            showQuickJumper: false,
            ...pagination,
        };

        const columns = [
            {
                title: '帐号',
                dataIndex: 'PhoneNum'
            },
            {
                title: '昵称',
                dataIndex: 'NickName'
            },
            {
                title: '用户类型',
                dataIndex: 'UserTypeText'
            },
            {
                title: '注册时间',
                dataIndex: 'CreatedTime',
                render: val => <span>{moment(val).format('YYYY/MM/DD')}</span>
            },
            {
                title: '操作',
                dataIndex: 'action',
                render: (text, record) => (
                    <span>
                        <Popconfirm title="确定删除?" okText="Yes" onConfirm={() => this.deleteUser(record)} cancelText="No">
                            <a >删除</a>
                        </Popconfirm>
                        <Divider type="vertical" />
                        <Popconfirm title="确定重置密码?" okText="Yes" onConfirm={() => this.resetPassword(record)} cancelText="No">
                            <a >重置密码</a>
                        </Popconfirm>
                        <Divider type="vertical" />
                        <a onClick={() => this.changeVisible(record)}>编辑</a>
                    </span>
                )
            }
        ];
        return (
            //标头
            <PageHeaderLayout title="用户列表">
                {/* 包裹table的白底块 */}
                <Card bordered={false}>
                    <div className={styles.tableList}>
                        <Form onSubmit={this.search} >
                            <Row gutter={{ md: 8, lg: 24, xl: 48 }}>
                                <Col md={6} sm={6}>
                                    <FormItem>
                                        {getFieldDecorator('phoneNum')(
                                            <Input placeholder="手机号" />
                                        )}
                                    </FormItem>
                                </Col>
                                <Col md={6} sm={6}>
                                    <FormItem>
                                        <Button type="primary" htmlType="submit">查询</Button>
                                    </FormItem>
                                </Col>
                            </Row>
                        </Form>
                        <Button className={style.addUser} icon="plus" type="primary" onClick={() => this.changeVisible()}>添加用户</Button>
                        <Table  
                            bordered={true}     
                            loading={loading}
                            dataSource={list}
                            pagination={paginationProps}
                            columns={columns}
                            onChange={() => this.tableChanger()}
                        />
                    </div>
                </ Card>
                <AdminModal onCancel={() => this.hideModal()} />
            </ PageHeaderLayout>
        )
    }
}
