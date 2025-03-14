FROM nginx:latest

RUN rm /etc/nginx/conf.d/default.conf

COPY nginx/nginx.conf /etc/nginx/nginx.conf
COPY nginx/api-cert.key /etc/ssl/private/api-cert.key
COPY nginx/api-cert.crt /etc/ssl/certs/api-cert.crt
COPY nginx/mvc-cert.key /etc/ssl/private/mvc-cert.key
COPY nginx/mvc-cert.crt /etc/ssl/certs/mvc-cert.crt

RUN mkdir -p /var/log/nginx
RUN touch /var/log/nginx/access.log /var/log/nginx/error.log

EXPOSE 8083

CMD ["nginx", "-g", "daemon off;"]