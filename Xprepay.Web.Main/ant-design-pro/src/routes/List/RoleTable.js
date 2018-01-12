import React, { PureComponent } from 'react';
import { connect } from 'dva';
import { Table, Row, Col, Card, Form, Input, Select, Icon, Button, Dropdown, Menu, InputNumber, DatePicker, Modal, message } from 'antd';
//import StandardTable from '../../components/StandardTable';
import PageHeaderLayout from '../../layouts/PageHeaderLayout';

import styles from './TableList.less';
const FormItem = Form.Item;
const getValue = obj => Object.keys(obj).map(key => obj[key]).join(',');
@connect(state => ({
    role: state.role,
}))
@Form.create()
export default class RoleTable extends PureComponent {
    state = {
        data: [],
        selectedRows: [],
        formValues: {}
    }
    componentDidMount() {
        console.log(styles)
        const { dispatch } = this.props;
        dispatch({
            type: 'role/getRoles',
        });
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
        console.log(sorter);
        dispatch({
            type: "role/searchRole",
            payload: {
                ...formValues,
                pagination: {
                    currentPage: pagination.current,
                    pageSize: pagination.pageSize,
                    sorter:sorter.field,
                    sortDirection:sorter.order
                },
            }
        })
    }
    handleSearch = (e) => {
        e.preventDefault();
        const { dispatch, form } = this.props;
        form.validateFields((err, fieldsValue) => {
            if (err) return;
            const values = {
                ...fieldsValue,
                //updatedAt: fieldsValue.updatedAt && fieldsValue.updatedAt.valueOf(),
            };

            this.setState({
                formValues: values,
            });
            dispatch({
                type: 'role/searchRole',
                payload: {
                    ...values,
                    pagination: {}
                }
            });
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
                sorter: true,
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

        const { data: { list, pagination }, loading } = this.props.role;
        const { getFieldDecorator, getFieldsError, getFieldError, isFieldTouched } = this.props.form;
        const paginationProps = {
            //显示每页显示多少条数据
            showSizeChanger: true,
            //快速跳转到第几页
            showQuickJumper: false,
            ...pagination,
        };

        return (
            //标头
            <PageHeaderLayout title="用户权限">
                {/* 包裹table的白底块 */}
                <Card bordered={false}>
                    <div className={styles.tableList}>
                        <Form onSubmit={this.handleSearch} >
                            <Row gutter={{ md: 8, lg: 24, xl: 48 }}>
                                <Col md={6} sm={6}>
                                    <FormItem>
                                        {getFieldDecorator('RoleName')(
                                            <Input placeholder="RoleName" />
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
                        <Table
                            bordered={true}
                            loading={loading}
                            dataSource={list}
                            pagination={paginationProps}
                            columns={columns}
                            onChange={this.tableChanger}
                        />
                    </div>
                </ Card>
            </ PageHeaderLayout>

        )
    }
}