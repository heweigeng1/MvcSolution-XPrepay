import React, { PureComponent } from 'react';
import { connect } from 'dva';
import { Table, Row, Col, Card, Form, Input, Select, Icon, Button, Dropdown, Menu, InputNumber, DatePicker, Modal, message } from 'antd';
const FormItem = Form.Item;
@connect(state => ({
    user: state.user,
}))
export default class UserModal extends PureComponent {
    state = {
        
    };
    isok = () => {
        
    }
    handleModalVisible = (flag) => {
        
    }
    changeInput = (e) => {
        // const { data: { nickName, phoneNum } } = this.state;
        // const { value } = e.target;
        // console.log(e.target)
        // this.setState({
        //     data: {
        //         nickName: e.target.name === 'nickName' ? value : nickName,
        //         phoneNum: e.target.name === 'phoneNum' ? value : phoneNum,
        //     },
        // })
        // console.log(this.state.data)
    }
    render() {
        const { onCancel } = this.props;
        const { modalData,modalVisible } = this.props.user;
        return (
            <Modal
                title="用户"
                visible={modalVisible}
                onOk={this.isok}
                onCancel={onCancel}
                destroyOnClose={true}
            >
                <FormItem
                    labelCol={{ span: 5 }}
                    wrapperCol={{ span: 15 }}
                    label="手机号"
                >
                    <Input placeholder='6-12个字符' name='phoneNum' onChange={this.changeInput} value={modalData.phoneNum}></Input>
                </FormItem>
                <FormItem
                    labelCol={{ span: 5 }}
                    wrapperCol={{ span: 15 }}
                    label="昵 称"
                >
                    <Input placeholder='6-12个字符' name='nickName' onChange={this.changeInput} value={modalData.nickName}></Input>
                </FormItem>
            </Modal>
        )
    }
}